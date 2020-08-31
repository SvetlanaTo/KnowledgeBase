using KnowledgeBase.Data;
using KnowledgeBase.Models;
using KnowledgeBase.ViewModels.Public;
using Lucene.Net.Analysis.Standard;
using Lucene.Net.Documents;
using Lucene.Net.Index;
using Lucene.Net.QueryParsers;
using Lucene.Net.Search;
using Lucene.Net.Store;
using Microsoft.AspNetCore.Hosting;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Security.AccessControl;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace KnowledgeBase.Helpers
{
    public class KbVaultLuceneHelper
    {
        //private const string putanja = "D:\\Svetlana\\2-Baza Znanja\\00 - new era\\stari kod\\KnowledgeBase - 1908-1\\KnowledgeBase\\Lucene";
        public IWebHostEnvironment _env;
        private readonly KnowledgeBaseContext _context;

        public KbVaultLuceneHelper(IWebHostEnvironment env, KnowledgeBaseContext context)
        {
            _env = env;
            _context = context;
        }


        //string path = AppDomain.CurrentDomain.BaseDirectory.Substring(0, AppDomain.CurrentDomain.BaseDirectory.IndexOf("\\bin"));


        //TREBA INJECTOVATI PUTANJU U OVAJ STATIC PROPERTY, STAVLJENO DA NE VRACA NISTA DA BI BUILD PROSAO
        //private static string LuceneIndexDirectory
        //{

        //    get
        //    {
        //        //return "";
        //        //kako radi 
        //        //return Path.Combine(_env.WebRootPath, "/Lucene");

        //        return Path.Combine(_env.ContentRootPath, "~/Lucene");




        //        //kako je bilo
        //        //return HttpContext.Current.Server.MapPath("~/Lucene");

        //    }
        //}

        public List<KbSearchResultItemViewModel> DoSearch(string text, int page = 1, int resultCount = 20)
        {
            var LuceneIndexDirectory = Path.Combine(_env.ContentRootPath, "Lucene");
            try
            {
                if (page < 1)
                {
                    throw new ArgumentException("Page");
                }

                if (string.IsNullOrEmpty(text))
                {
                    throw new ArgumentNullException("Search Text");
                }

                var results = new List<KbSearchResultItemViewModel>();
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                var searcher = new IndexSearcher(FSDirectory.Open(LuceneIndexDirectory));


                var fields = new string[] { "Title", "Content" };
                var parser = new MultiFieldQueryParser(Lucene.Net.Util.Version.LUCENE_30, fields, analyzer);
                var q = ParseQuery(text, parser);
                var hits = searcher.Search(q, page * resultCount);
                if (hits.ScoreDocs.Any())
                {
                    for (int i = (page - 1) * resultCount; i < hits.ScoreDocs.Count(); i++)
                    {
                        var doc = searcher.Doc(hits.ScoreDocs[i].Doc);

                        var item = new KbSearchResultItemViewModel
                        {
                            ArticleId = Convert.ToInt32(doc.Get("Id").ToString().Replace("KB-", string.Empty).Replace("AT-", string.Empty)),
                            IsArticle = doc.Get("Id").StartsWith("KB-"),
                            IsAttachment = doc.Get("Id").StartsWith("AT-"),
                            ArticleTitle = doc.Get("Title")
                        };
                        //2808
                        var article = _context.Articles.FirstOrDefault(a => a.Id == item.ArticleId);
                        if (article != null)
                        {
                            item.ArticleSefName = article.SefName;
                        }
                        else
                            item.ArticleSefName = null;

                        results.Add(item);
                    }
                }

                searcher.Dispose();
                return results;
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
        }

        public void RemoveArticleFromIndex(Article article)
        {
            var LuceneIndexDirectory = Path.Combine(_env.ContentRootPath, "Lucene");

            try
            {
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                IndexWriter writer;

                try
                {
                    writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, false, IndexWriter.MaxFieldLength.UNLIMITED);
                }
                catch (System.IO.FileNotFoundException)
                {
                    writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, true, IndexWriter.MaxFieldLength.UNLIMITED);
                }

                using (var searcher = new IndexSearcher(FSDirectory.Open(LuceneIndexDirectory)))
                {
                    var term = new Term("Id", "KB-" + article.Id.ToString());
                    var q = new TermQuery(term);
                    var docs = searcher.Search(q, 10);

                    writer.DeleteDocuments(term);
                    writer.Optimize();
                    writer.Commit();
                    writer.Dispose();
                }
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
            finally
            {
                IndexWriter.Unlock(FSDirectory.Open(LuceneIndexDirectory));
            }
        }

        public void AddArticleToIndex(Article article)
        {
            var LuceneIndexDirectory = Path.Combine(_env.ContentRootPath, "Lucene");

            try
            {
                RemoveArticleFromIndex(article);
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                //var writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, false, IndexWriter.MaxFieldLength.UNLIMITED);
                var writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, false, IndexWriter.MaxFieldLength.UNLIMITED);

                var doc = new Document();
                var decodedHtml = HttpUtility.HtmlDecode(article.Content);
                doc.Add(new Field("Id", "KB-" + article.Id.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                doc.Add(new Field("Title", article.Title, Field.Store.YES, Field.Index.ANALYZED));
                doc.Add(new Field("Content", StripTagsCharArray(decodedHtml), Field.Store.YES, Field.Index.ANALYZED));

                writer.AddDocument(doc);
                writer.Optimize();
                writer.Commit();
                writer.Dispose();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
            finally
            {
                IndexWriter.Unlock(FSDirectory.Open(LuceneIndexDirectory));
            }
        }

        public void RemoveAttachmentFromIndex(Attachment attachment)
        {
            var LuceneIndexDirectory = Path.Combine(_env.ContentRootPath, "Lucene");

            try
            {
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                var writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, false, IndexWriter.MaxFieldLength.UNLIMITED);
                var term = new Term("Id", "AT-" + attachment.Id.ToString());
                writer.DeleteDocuments(term);
                writer.Optimize();
                writer.Commit();
                writer.Dispose();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
            finally
            {
                IndexWriter.Unlock(FSDirectory.Open(LuceneIndexDirectory));
            }
        }

        public void AddAttachmentToIndex(Attachment attachment)
        {
            var LuceneIndexDirectory = Path.Combine(_env.ContentRootPath, "Lucene");

            try
            {
                var analyzer = new StandardAnalyzer(Lucene.Net.Util.Version.LUCENE_30);
                var writer = new IndexWriter(FSDirectory.Open(LuceneIndexDirectory), analyzer, false, IndexWriter.MaxFieldLength.UNLIMITED);
                var doc = new Document();
                var path = Path.Combine(attachment.Path);
                //var path = HttpContext.Current.Server.MapPath(attachment.Path);
                var localFilePath = Path.Combine(path, attachment.FileName);
                if (File.Exists(localFilePath))
                {
                    var reader = new StreamReader(new FileStream(Path.Combine(path, attachment.FileName), FileMode.Open));
                    doc.Add(new Field("Id", "AT-" + attachment.ArticleId.ToString(), Field.Store.YES, Field.Index.NOT_ANALYZED));
                    doc.Add(new Field("Title", attachment.FileName, Field.Store.YES, Field.Index.ANALYZED));
                    doc.Add(new Field("Content", reader, Field.TermVector.WITH_POSITIONS));
                    writer.AddDocument(doc);
                }

                writer.Optimize();
                writer.Commit();
                writer.Dispose();
            }
            catch (Exception ex)
            {
                LogManager.GetCurrentClassLogger().Error(ex);
                throw;
            }
            finally
            {
                IndexWriter.Unlock(FSDirectory.Open(LuceneIndexDirectory));
            }
        }


        private Query ParseQuery(string searchQuery, QueryParser parser)
        {
            Query q;
            try
            {
                q = parser.Parse(searchQuery.Trim() + "*");
            }
            catch (ParseException e)
            {
                LogManager.GetCurrentClassLogger().Error("Query parser exception", e);
                q = null;
            }

            if (string.IsNullOrEmpty(q?.ToString()))
            {
                var cooked = Regex.Replace(searchQuery, @"[^\w\.@-]", " ");
                q = parser.Parse(cooked);
            }

            return q;
        }

        // Taken from
        // http://www.dotnetperls.com/remove-html-tags
        private static string StripTagsCharArray(string source)
        {
            var array = new char[source.Length];
            var arrayIndex = 0;
            var inside = false;

            for (int i = 0; i < source.Length; i++)
            {
                var let = source[i];
                if (let == '<')
                {
                    inside = true;
                    continue;
                }

                if (let == '>')
                {
                    inside = false;
                    continue;
                }

                if (!inside)
                {
                    array[arrayIndex] = let;
                    arrayIndex++;
                }
            }

            return new string(array, 0, arrayIndex);
        }
    }
}

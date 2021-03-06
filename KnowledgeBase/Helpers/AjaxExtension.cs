﻿//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace KnowledgeBase.Helpers
//{
//    /// <summary>
//    /// Determines whether the specified HTTP request is an AJAX request.
//    /// </summary>
//    /// 
//    /// <returns>
//    /// true if the specified HTTP request is an AJAX request; otherwise, false.
//    /// </returns>
//    /// <param name="request">The HTTP request.</param><exception cref="T:System.ArgumentNullException">The <paramref name="request"/> parameter is null (Nothing in Visual Basic).</exception>
//    public static bool IsAjaxRequest(this HttpRequestBase request)
//    {
//        if (request == null)
//            throw new ArgumentNullException(nameof(request));
//        if (request["X-Requested-With"] == "XMLHttpRequest")
//            return true;
//        if (request.Headers != null)
//            return request.Headers["X-Requested-With"] == "XMLHttpRequest";
//        return false;
//    }
//}

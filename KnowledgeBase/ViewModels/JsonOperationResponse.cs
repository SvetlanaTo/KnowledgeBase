﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KnowledgeBase.ViewModels
{
    public class JsonOperationResponse
    {
        public JsonOperationResponse()
        {
            Successful = false;
        }

        public bool Successful { get; set; }
        public string ErrorMessage { get; set; }
        public object Data { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3.Repository
{
    public class RepositoryPaises
    {
        public Pais DevuelveInfoPaises()
        {
            HttpClient client = new HttpClient();
            var response = client.GetAsync("https://restcountries.com/v3.1/all");
        }
    }
}
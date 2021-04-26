using Microsoft.AspNetCore.Http;
using Miktobutik.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace MikroButik.Common
{
    public   class ApiClient
    {      
        private string ApiURL = "https://localhost:44375/api/";
        public HttpClient GetClient() {
            var c = new HttpClient();
            //c.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("BEARER", "Token");
            return c;
        }     
        
        public T PostData<T>(string endpoint, object data) {
            var cli = GetClient();
            var d = new StringContent(System.Text.Json.JsonSerializer.Serialize(data), System.Text.Encoding.UTF8, "application/json");
            dynamic nul = null;    
            var res = cli.PostAsync(ApiURL + endpoint, d).Result;  
            if (res.IsSuccessStatusCode)
            {
                var gelen = res.Content.ReadAsStringAsync().Result;
                T result = System.Text.Json.JsonSerializer.Deserialize<T>(gelen);
                return result;
            }
            else {
               
                return nul;
            } 
            return nul;
        }

        public T PostDataFileSupported<T>(string endpoint, object data)
        {
            var cli = GetClient();   
            dynamic nul = null;

            var form = new MultipartFormDataContent();
            var mem = new MemoryStream();
            foreach (var item in data.GetType().GetProperties())
            {
                if (item.PropertyType == typeof(IFormFile))
                {
                        IFormFile file = (IFormFile)item.GetValue(data);  
                        file.CopyTo(mem);
                        var fileContent = new ByteArrayContent(mem.ToArray());  
                        fileContent.Headers.ContentType = MediaTypeHeaderValue.Parse("multipart/form-data");
                        form.Add(fileContent, item.Name, file.Name);    
                }
                else {
                    if (item.GetValue(data) != null)
                    {
                        form.Add(new StringContent(item.Name), item.GetValue(data).ToString());
                    }   
                }
              
            }  

            var res = cli.PostAsync(ApiURL + endpoint, form).Result;
            mem.DisposeAsync();
            form.Dispose();
            if (res.IsSuccessStatusCode)
            {
                var gelen = res.Content.ReadAsStringAsync().Result;
                T result = System.Text.Json.JsonSerializer.Deserialize<T>(gelen);
                return result;
            }
            else
            {

                return nul;
            }
            return nul;
        }
        public T GetData<T>(string endpoint) {  
            var cli = GetClient();
            var res = cli.GetStringAsync(ApiURL + endpoint).Result; 
            T result = System.Text.Json.JsonSerializer.Deserialize<T>(res);
            return result;
        }   
    }
}

using System;

namespace WebRequestTestAnalytics {
    using System.Net;
    using System.Collections.Generic; 
    using System.IO; 
    using System.Xml; 
    
    class WebReader
    {
        private string _apiAddress;
        private NetworkCredential _credentials;

        public WebReader(string apiAddress, NetworkCredential credentials)
        {
            _apiAddress = apiAddress;
            _credentials = credentials;
        }

        public IEnumerable<string> GetData()
         { 
             List<string> resultList = new List<string>(); 
             HttpWebRequest request = (HttpWebRequest)WebRequest.Create(this._apiAddress); 
             request.Method = "GET";
             request.Credentials = this._credentials; 
 
 
             using (HttpWebResponse response = (HttpWebResponse)request.GetResponse()) 
             { 
                 if (response.StatusCode != HttpStatusCode.OK) 
                 { 
                 } 
                 else 
                 { 
                     Stream responseStream = response.GetResponseStream(); 
                     if (responseStream != null) 
                     { 
                         try 
                         { 
                             StreamReader reader = new StreamReader(responseStream); 
                             string originalText = reader.ReadToEnd();
                             resultList.Add(originalText);

                            /*  IEnumerable<XmlDocument> documents = GetXmlFromOriginalText(originalText); 


                              foreach (XmlDocument document in documents) 
                              { 
                                  string resultString = ProcessDocument(document); 
                                  if (resultString != null) 
                                  { 
                                      resultList.Add(resultString); 
                                  } 
                              } */
                        } 
                         catch (Exception) 
                         { 
                             //error in reading 
                         } 
                     } 
                 } 
             } 
             return resultList; 
         } 

    }
}

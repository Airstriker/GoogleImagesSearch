// Copyright (c) 2016 Julian Sychowski
// License: For non-commercial use only

using System;
using System.Collections.Generic;
using System.Linq;
using NSoup;
using System.Text.RegularExpressions;

namespace GoogleImagesSearch
{
    /// <summary>
    /// Searches for images using google websearch
    /// </summary>
    public class GoogleImagesSearcher
    {
        #region Properties

            /// <summary>
            /// Gets the time taken to perform the translation.
            /// </summary>
            public TimeSpan SearchTime {
                get;
                private set;
            }

            /// <summary>
            /// Gets the error.
            /// </summary>
            public Exception Error {
                get;
                private set;
            }

        #endregion

        #region Public methods

            /// <summary>
            /// Translates the specified source text.
            /// </summary>
            /// <param name="image">The source text.</param>
            /// <returns>The translation.</returns>
            public List<String> SearchForImages(string image)
            {
                // Initialize
                this.Error = null;
                this.SearchTime = TimeSpan.Zero;
                DateTime timeStart = DateTime.Now;

                //Other searching concepts:
                //string url = string.Format ("https://translate.googleapis.com/translate_a/single?client=gtx&sl={0}&tl={1}&dt=t&q={2}",
                //string url = string.Format("https://clients1.google.com/complete/search?client=htsa&hl=pl&ds=i&q={0}",
                //string url = string.Format("http://www.google.com/search?sourceid=chrome&client=htsa&hl=pl&ds=i&q={0}",
                //string url = string.Format("https://ajax.googleapis.com/ajax/services/search/web?v=1.0&q=Paris%20Hilton&gl=pl");//,
                //string url = string.Format("https://ajax.googleapis.com/ajax/services/search/images?v=1.0&q=Paris%20Hilton&gl=pl&userip=192.168.0.1");//,
                //string url = string.Format("https://www.googleapis.com/customsearch/v1?key=ap_key&cx=cx&q=hello&searchType=image&imgSize=xlarge&alt=json&num=10&start=1");//,
                //string url = string.Format("https://www.google.com/search?tbm=isch&q=dupa");//,
                //8 resultatów: &rsz=large

                List<String> images = FindImages(image, "Mozilla/5.0 (Windows NT 6.1) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/41.0.2228.0 Safari/537.36");

                // Return result
                this.SearchTime = DateTime.Now - timeStart;
                return images;
            }

        #endregion

        #region Private methods

            public List<String> FindImages(String question, String userAgent)
            {
                List<String> imagesList = new List<String>();

                try
                {
                    String googleUrl = "https://www.google.com/search?tbm=isch&q=" + question.Replace(",", "");

                    NSoup.Nodes.Document htmlDoc = NSoupClient.Connect(googleUrl).UserAgent(userAgent).Timeout(10 * 1000).Get();
                    //Handling correctly auto redirects... 
                    checkForRedirectsOnHTMLDocument(ref htmlDoc, userAgent);

                    /*
                    //This is old method
                    NSoup.Select.Elements images = htmlDoc.Select("div.rg_di.rg_el.ivg-i img"); //div with class="rg_di rg_el ivg-i" containing img
                    foreach (NSoup.Nodes.Element img in images) {
                        NSoup.Select.Elements links = img.Parent.Select("a[href]");
                        if (links.Count() > 0) { //is there a link around img?
                            NSoup.Nodes.Element link = img.Parent.Select("a[href]").First();
                            String href = img.Parent.Attr("abs:href"); //link which needs to be parsed to get the full img url
                            Regex regex = new Regex("imgurl=(.*?)&imgrefurl="); //Everything between "imgurl=" and "&imgrefurl="
                            var v = regex.Match(href);
                            if (v != null && v.Groups.Count == 2) {
                                if (v.Groups[1].Value != String.Empty) {
                                    String imgURL = v.Groups[1].ToString();
                                    imagesList.Add(imgURL);
                                }
                            }
                        }
                    }
                    */
                    NSoup.Select.Elements div_with_images = htmlDoc.Select("div.y.yi div.rg_di.rg_bx.rg_el.ivg-i"); //div with class="y yi" containing div with class="rg_di rg_bx rg_el ivg-i"
                    foreach (NSoup.Nodes.Element div_with_image in div_with_images) {
                        NSoup.Nodes.Element rg_meta_div = div_with_image.Select("div.rg_meta").First();
                        String text_where_the_img_is = rg_meta_div.ToString();
                        Regex regex = new Regex("ou&quot;:&quot;(.*?)&quot;"); //Everything between "ou&quot;:&quot;" and "&quot;"
                        var v = regex.Match(text_where_the_img_is);
                        if (v != null && v.Groups.Count == 2) {
                            if (v.Groups[1].Value != String.Empty) {
                                String imgURL = v.Groups[1].ToString();
                                imagesList.Add(imgURL);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    this.Error = ex;
                }

                return imagesList;
            }

            private static void checkForRedirectsOnHTMLDocument(ref NSoup.Nodes.Document htmlDoc, String userAgent) {
                //Checking if http-equiv=refresh
                foreach (NSoup.Nodes.Element refresh in htmlDoc.Select("html head meta[http-equiv=refresh]")) {
                    String matcher = refresh.Attr("content");
                    Regex regex = new Regex("url=(.*)");
                    var v = regex.Match(matcher);

                    if (v != null && v.Groups.Count == 2) {
                        if (v.Groups[1].Value != String.Empty) {
                            //Need to know the base uri:
                            String baseURI = getBaseURI(htmlDoc);
                            String urlToFetch = baseURI + v.Groups[1].ToString();
                            htmlDoc = NSoupClient.Connect(urlToFetch).UserAgent(userAgent).Timeout(10 * 1000).Get();
                            checkForRedirectsOnHTMLDocument(ref htmlDoc, userAgent);
                        }   
                    }
                }

                //Javascript based redirection handling
                foreach (NSoup.Nodes.Element javascript in htmlDoc.Select("html head script[type=text/javascript]")) {
                    String matcher = javascript.ToString();
                    Regex regex = new Regex("window.google.gbvu='(.*?)'");
                    var v = regex.Match(matcher);
                    if (v !=null && v.Groups.Count == 2) {
                        if (v.Groups[1].Value != String.Empty) {
                            //Need to know the base uri:
                            String baseURI = getBaseURI(htmlDoc);
                            String urlToFetch = baseURI + v.Groups[1].ToString().Replace("\\75", "=").Replace("\\075", "=").Replace("\\x3d", "=").Replace("\\46", "&").Replace("\\046", "&").Replace("\\x26", "&"); //converting ASCII octet codes to characters
                            htmlDoc = NSoupClient.Connect(urlToFetch).UserAgent(userAgent).Timeout(10 * 1000).Get();
                            checkForRedirectsOnHTMLDocument(ref htmlDoc, userAgent);
                        }
                    }
                }
            }

            private static String getBaseURI(NSoup.Nodes.Document htmlDoc) {
                String baseURI = htmlDoc.BaseUri;
                Regex regex = new Regex("(.*)/"); //e.g. https://google.pl
                var v = regex.Match(baseURI);

                if (v != null && v.Groups.Count == 2) {
                    if (v.Groups[1].Value != String.Empty) {
                        return v.Groups[1].ToString();
                    }
                }
                return String.Empty;
            }

        #endregion
    }
}

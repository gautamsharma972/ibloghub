using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace iBlogHub.Helpers
{
    public class MinReads
    {
        string Content;        
        
        public MinReads(string _contents)
        {
            Content = _contents;
        }
        public string TotalMinReads()
        {
            int words = 0;
            int l = 0;
            while (l <= Content.Length - 1)
            {
                if (Content[l] == ' ' || Content[l] == '\n' || Content[l] == '\t')
                {
                    words++;
                }

                l++;
            }
            if (words < 360)
            {
                return "1 min read";
            }
            else
            {
                return (words / 180) + " mins read";
            }
        }
    }
}
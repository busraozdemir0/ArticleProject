using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Entity.DTOs.SocialMedias
{
    public class SocialMediaDto
    {
        public int Id { get; set; }
        public string GmailUrl { get; set; }
        public string InstagramUrl { get; set; }
        public string TwitterUrl { get; set; }
        public string LinkedinUrl { get; set; }
        public string GithubUrl { get; set; }
    }
}

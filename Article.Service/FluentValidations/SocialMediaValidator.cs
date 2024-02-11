using Article.Entity.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Article.Service.FluentValidations
{
    public class SocialMediaValidator:AbstractValidator<SocialMedia>
    {
        public SocialMediaValidator()
        {
            RuleFor(x => x.GmailUrl)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Gmail URL");

            RuleFor(x => x.InstagramUrl)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Instagram URL");

            RuleFor(x => x.GithubUrl)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("GitHub URL");

            RuleFor(x => x.TwitterUrl)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Twitter URL");

            RuleFor(x => x.LinkedinUrl)
                .NotEmpty()
                .MinimumLength(3)
                .WithName("Linkedin URL");
        }
    }
}

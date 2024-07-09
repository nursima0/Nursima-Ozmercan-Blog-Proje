using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Concrete;
using DataAccessLayer.Concrete;

namespace BusinessLayer.Concrete
{
    public class UserProfileManager
    {
        Repository<Author> repouser = new Repository<Author>();
        Repository<Blog> repouserblog = new Repository<Blog>();

        public List<Author> GetAuthorByMail(string p)
        {
            return repouser.List(x => x.AuthorMail == p);
        }

        public List<Blog> GetBlogByAuthor(int id)
        {
            return repouserblog.List(x => x.AuthorID == id);
        }

        public void EditAuthor(Author a)
        {
            Author author = repouser.Find(x => x.AuthorID == a.AuthorID);
            author.AuthorName = a.AuthorName;
            author.AuthorImage = a.AuthorImage;
            author.AuthorAbout = a.AuthorAbout;
            author.AuthorTitle = a.AuthorTitle;
            author.AboutShort = a.AboutShort;
            author.AuthorMail = a.AuthorMail;
            author.Password = a.Password;
            author.PhoneNumber = a.PhoneNumber;
            repouser.Update(author);

        }
    }
}

using Beckend.DataLayer.Models;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.TagRepository
{
    public class TagRepository : ITagRepository
    {
        private DatabaseContext _context;

        public TagRepository(DatabaseContext database)
        {
            _context = database;
        }
        public void CreateTag(Tag Tag)
        {
            if (Tag == null)
            {
                throw new ArgumentNullException(nameof(Tag));
            }
            _context.Add(Tag);

        }
        public void DeleteTag(Tag Tag)
        {
            if (Tag == null)
            {
                throw new ArgumentNullException(nameof(Tag));
            }
            _context.Tags.Remove(Tag);
        }

        public Tag GetTagById(int id)
        {
            return _context.Tags.FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Tag> GetAllTags()
        {
            return _context.Tags.ToList();
        }

        public bool SaveTagChanges()
        {
            return _context.SaveChanges() >= 0;
        }

        public void UpdateTag(Tag Tag)
        {
            _context.Update(Tag);
        }
    }
}

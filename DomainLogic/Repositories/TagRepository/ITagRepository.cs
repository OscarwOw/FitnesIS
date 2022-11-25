using Beckend.DataLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Beckend.DomainLayer.Repositories.TagRepository
{
    public interface ITagRepository
    {
        bool SaveTagChanges();

        IEnumerable<Tag> GetAllTags();
        Tag GetTagById(int id);
        void CreateTag(Tag Tag);
        void UpdateTag(Tag Tag);
        void DeleteTag(Tag Tag);
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Domain.Models;
using Dev33.UltimateTeam.Infrastructure.Context;
using Dev33.UltimateTeam.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using UltimateTeam.Application.Contracts.Repositories;

namespace UltimateTeam.Infrastructure.Repositories
{
    public class TagRepository : BaseRepository<Tag>, ITagRepository
    {
        public TagRepository(SafeInformationDBContext context) : base(context)
        {
        }

        public async Task AddTagsAsync(List<Tag> tagMapped)
        {
            await context.Set<Tag>().AddRangeAsync(tagMapped);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Tag>> GetTagsAsync(Guid informationId)
        {
            return await context.Set<Tag>().Where(x => x.InformationId == informationId).ToListAsync();
        }

        public async Task RemoveTagsAsync(Guid informationId)
        {
            try
            {
                var tags = await GetTagsAsync(informationId);

                foreach (var tag in tags)
                {
                    await DeleteAsync(tag);
                }

                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Domain.Models;

namespace UltimateTeam.Application.Contracts.Repositories
{
    public interface ITagRepository : IAsyncRepository<Tag>
    {
        public Task<IEnumerable<Tag>> GetTagsAsync(Guid informationId);
        public Task RemoveTagsAsync(Guid informationId);
        Task AddTagsAsync(List<Tag> tagMapped);
    }
}
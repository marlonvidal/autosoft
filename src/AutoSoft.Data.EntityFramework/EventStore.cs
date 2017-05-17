using AutoSoft.Data.Entities;
using AutoSoft.Infrastructure.Domain;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutoSoft.Data.EntityFramework
{
    public class EventStore : IEventStore
    {
        private readonly DbContext _dbContext;
        private readonly IIdentity _identity;

        public EventStore(DbContext dbContext, IIdentity identity)
        {
            _dbContext = dbContext;
            _identity = identity;
        }

        public void SaveEvent<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
            using (_dbContext)
            {
                var aggregate = _dbContext.Set<DomainAggregateModel>().FirstOrDefault(x => x.Id == @event.AggregateRootId);

                if (aggregate == null)
                {
                    _dbContext.Set<DomainAggregateModel>().Add(new DomainAggregateModel
                    {
                        Id = @event.AggregateRootId,
                        Type = typeof(TAggregate).AssemblyQualifiedName
                    });
                }

                var currentSequenceCount = _dbContext.Set<Entities.DomainEventModel>().Count(x => x.DomainAggregateId == @event.AggregateRootId);

                var userId = _dbContext.Set<UsuarioModel>()
                        .Where(x => x.Login == _identity.Name)
                        .Select(x => x.Id)
                        .FirstOrDefault();

                _dbContext.Set<Entities.DomainEventModel>().Add(new Entities.DomainEventModel
                {
                    DomainAggregateId = @event.AggregateRootId,
                    SequenceNumber = currentSequenceCount + 1,
                    Type = @event.GetType().AssemblyQualifiedName,
                    Body = JsonConvert.SerializeObject(@event),
                    TimeStamp = @event.TimeStamp,
                    UserId = userId
                });

                _dbContext.SaveChanges();
            }
        }

        public async Task SaveEventAsync<TAggregate>(IDomainEvent @event) where TAggregate : IAggregateRoot
        {
            using (_dbContext)
            {
                var aggregate = await _dbContext.Set<DomainAggregateModel>().FirstOrDefaultAsync(x => x.Id == @event.AggregateRootId);

                if (aggregate == null)
                {
                    _dbContext.Set<DomainAggregateModel>().Add(new DomainAggregateModel
                    {
                        Id = @event.AggregateRootId,
                        Type = typeof(TAggregate).AssemblyQualifiedName
                    });
                }

                var currentSequenceCount = await _dbContext.Set<Entities.DomainEventModel>().CountAsync(x => x.DomainAggregateId == @event.AggregateRootId);                

                var userId = await _dbContext.Set<UsuarioModel>()
                        .Where(x => x.Login == _identity.Name)
                        .Select(x => x.Id)
                        .FirstOrDefaultAsync();

                _dbContext.Set<Entities.DomainEventModel>().Add(new Entities.DomainEventModel
                {
                    DomainAggregateId = @event.AggregateRootId,
                    SequenceNumber = currentSequenceCount + 1,
                    Type = @event.GetType().AssemblyQualifiedName,
                    Body = JsonConvert.SerializeObject(@event),
                    TimeStamp = @event.TimeStamp,
                    UserId = userId
                });

                await _dbContext.SaveChangesAsync();
            }
        }
    }
}

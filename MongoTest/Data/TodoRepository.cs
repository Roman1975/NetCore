using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoTest.Model;

namespace MongoTest.Data
{

    public class TodoRepository : ITodoRepository
    {
        private readonly MongoContext _context = null;

        public TodoRepository(IOptions<Settings> settings)
        {
            _context = new MongoContext(settings);
        }

        public async Task<IEnumerable<Todo>> GetAll()
        {
            try
            {
                return await _context.Todos
                        .Find(x => true).ToListAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        // query after Id or InternalId (BSonId value)
        //
        public async Task<Todo> Get(string id)
        {
            try
            {
                var guid = Guid.Parse(id);
                ObjectId internalId = GetInternalId(id);
                
                return await _context.Todos
                                .Find(todo => todo.InternalId == internalId
                                || todo.Id == guid)
                                .FirstOrDefaultAsync();
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        private ObjectId GetInternalId(string id)
        {
            ObjectId internalId;
            if (!ObjectId.TryParse(id, out internalId))
                internalId = ObjectId.Empty;

            return internalId;
        }

        public async Task Add(Todo item)
        {
            try
            {
                await _context.Todos.InsertOneAsync(item);
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

         public async Task AddComment(string id, Comment item)
        {
            try
            {
                var filter = Builders<Todo>.Filter.Eq("Id", id);
                var push = Builders<Todo>.Update.Push("Comments", item);
                //var update = Builders<Todo>.Update.Push("Comments", item);

                await _context.Todos.UpdateOneAsync(filter, push, new UpdateOptions(){IsUpsert = true});
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Remove(string id)
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Todos.DeleteOneAsync(
                        Builders<Todo>.Filter.Eq("Id", id));

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Complete(string id)
        {
            try
            {
                var filter = Builders<Todo>.Filter.Eq("Id", id);
                var update = Builders<Todo>.Update.Set("Complete", true).CurrentDate("CompletedOn");
                UpdateResult actionResult = await _context.Todos.UpdateOneAsync(filter, update);

                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> Update(string id, Todo item)
        {
            try
            {
                var guid = Guid.Parse(id);
                ReplaceOneResult actionResult
                    = await _context.Todos
                                    .ReplaceOneAsync(n => n.Id == guid
                                            , item
                                            , new UpdateOptions { IsUpsert = true });
                return actionResult.IsAcknowledged
                    && actionResult.ModifiedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> RemoveAll()
        {
            try
            {
                DeleteResult actionResult
                    = await _context.Todos.DeleteManyAsync(new BsonDocument());

                return actionResult.IsAcknowledged
                    && actionResult.DeletedCount > 0;
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }
    }
}
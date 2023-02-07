using MongoDB.Driver;
using VisitorsNationality.Models;

namespace VisitorsNationality.Services
{
    public class VisitorsService : IVisitorsService
    {
        private readonly IMongoCollection<Visitor> _visitors;

        public VisitorsService(IVisitorsDatabaseSettings settings, IMongoClient mongoClient)
        {
            var database = mongoClient.GetDatabase(settings.DatabaseName);
            _visitors = database.GetCollection<Visitor>(settings.CollectionName);     
        }
        public Visitor Create(Visitor newVisitor)
        {
            _visitors.InsertOne(newVisitor);
            return newVisitor;
        }

        public List<Visitor> Get()
        {
            return _visitors.Find(visitor => true).ToList();
        }

        public Visitor Get(string name)
        {
            return _visitors.Find(visitor => visitor.Name == name).FirstOrDefault();
        }
    }
}

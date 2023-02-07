using VisitorsNationality.Models;

namespace VisitorsNationality.Services
{
    public interface IVisitorsService
    {
        List<Visitor> Get();
        Visitor Get(string name);
        Visitor Create(Visitor newVisitor);
    }
}

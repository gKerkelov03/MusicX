using Musical_Competition.Data.Models;

namespace Musical_Competition.Data.Repositories;

public class JudgesRepository : BaseRepository<Judge>
{
    public JudgesRepository(ApplicationDbContext context) : base(context) { }
}

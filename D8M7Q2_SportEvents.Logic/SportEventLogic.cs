using D8M7Q2_SportEvents.Entities;
using MovieClub.Data;

namespace D8M7Q2_SportEvents.Logic
{
    public class SportEventLogic
    {
        Repository<SportEvent> repo;

        public SportEventLogic(Repository<SportEvent> repo)
        {
            this.repo = repo;
        }

        public void AddSportEvent()
        {

        }
    }
}

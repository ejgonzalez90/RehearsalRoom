using RehearsalRoom.Model;

namespace RehearsalRoom.Repository
{
    public class PlayerRepository : GenericRepo<Player>
    {
        //TODO: Interfaz

        public PlayerRepository(RehearsalRoomContext db) : base(db)
        {
        }
    }
}

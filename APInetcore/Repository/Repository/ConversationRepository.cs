using Repository.EF;
using Repository.Interface;

namespace Repository.Repository
{
    public class ConversationRepository : BaseRepository<Conversation>, IConversationRepository
    {
    }
}

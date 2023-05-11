using Microsoft.EntityFrameworkCore;
using ValgenConfigurationApp.Repository.Models;
using ValgenConfigurationApp.Services.Models;

namespace ValgenConfigurationApp.Repository
{
    /// <summary>
    /// SubscriberRepository class.
    /// </summary>
    
    public class SubscriberRepository : ISubscriberRepository
    {
        private readonly DatabaseContext _databaseContext;

        public SubscriberRepository(DatabaseContext databaseContext)
        {
            if (databaseContext == null)
                throw new ArgumentNullException(nameof(databaseContext));

            _databaseContext = databaseContext;
        }

        // Method for Getting the list of Subscribers.
        public async Task<List<SubscriberModel>> GetAllSubscribers()
        {
            List<Subscribers> subscribers = new List<Subscribers>();
            try
            {
                subscribers = await _databaseContext.Subscribers.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
            return ToSubscriberModel(subscribers);
        }

        // Method for creating new Subscriber.
        public async Task<SubscriberModel> CreateNewSubscriber(SubscriberModel model)
        {
            _databaseContext.Subscribers.Add(ToSubscribers(model));
            await _databaseContext.SaveChangesAsync();
            Subscribers subscriber = await _databaseContext.Subscribers.FirstAsync(u => u.Token == model.SubscriberToken);
            return ConvertIntoSubscriberModel(subscriber);
        }

        // Method for updating subscriber details.
        public async Task<SubscriberModel> UpdateSubscriber(SubscriberRequestModel model, Guid id)
        {
            Subscribers subscriber = await _databaseContext.Subscribers.FirstAsync(u => u.Id == id);
            if(subscriber == null)
            {
                throw new ArgumentException("Subscriber not found"); ;
            }

            subscriber.UserName = model.UserName;
            subscriber.Email = model.Email;
            subscriber.Phone = model.Phone;
            subscriber.StartDate = model.StartDate;
            subscriber.EndDate = model.EndDate;
            subscriber.ConfigJSON = model.ConfigJSON;

            return ConvertIntoSubscriberModel(subscriber);
        }

        // Method for mapping List<Subscribers> into List<SubscriberModel>.
        private List<SubscriberModel> ToSubscriberModel(List<Subscribers> subscriberList)
        {
            var subs = subscriberList.Select(s => new SubscriberModel
            {
                Id = s.Id,
                UserName = s.UserName,
                Email = s.Email,
                Phone = s.Phone,
                SubscriberToken = s.Token,
                StartDate = s.StartDate,
                EndDate = s.EndDate,
                ConfigJSON = s.ConfigJSON,
                isActive = s.isActive
            }).ToList();

            return subs;
        }

        private Subscribers ToSubscribers(SubscriberModel model)
        {
            return new Subscribers()
            {
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                Token = model.SubscriberToken,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ConfigJSON = model.ConfigJSON,
                isActive = model.isActive
            };
        }

        private SubscriberModel ConvertIntoSubscriberModel(Subscribers model)
        {
            return new SubscriberModel
            {
                Id = model.Id,
                UserName = model.UserName,
                Email = model.Email,
                Phone = model.Phone,
                SubscriberToken = model.Token,
                StartDate = model.StartDate,
                EndDate = model.EndDate,
                ConfigJSON = model.ConfigJSON,
                isActive = model.isActive
            };
        }
    }
}

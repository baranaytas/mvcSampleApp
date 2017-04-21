using AutoMapper;
using Data;
using Entity;

namespace Bus
{
    public static class AutoMapperConfiguration
    {
        public static void Configure()
        {
            ConfigureJournalMapping();
        }

        private static void ConfigureJournalMapping()
        {
            Mapper.CreateMap<Journal, JournalModel>().ForMember(x => x.Publishes, y => y.MapFrom(z => z.Publishes));
            Mapper.CreateMap<JournalModel, Journal>().ForMember(x => x.Publishes, y => y.MapFrom(z => z.Publishes));

            Mapper.CreateMap<PublishModel, Publish>();
            Mapper.CreateMap<Publish,PublishModel>();

            Mapper.CreateMap<SubscriberModel, Subscriber>()
                .ForMember(x => x.SubscriberJournals, y => y.MapFrom(z => z.SubscriberJournalsList));
            Mapper.CreateMap<Subscriber, SubscriberModel>()
                .ForMember(x => x.SubscriberJournalsList, y => y.MapFrom(z => z.SubscriberJournals));

            Mapper.CreateMap<SubscriberJournal, SubscriberJournalModel>()
                .ForMember(x => x.Journal, y => y.MapFrom(z => z.Journal))
                .ForMember(x => x.Subscriber, y => y.MapFrom(z => z.Subscriber));

            Mapper.CreateMap<SubscriberJournalModel, SubscriberJournal>()
                .ForMember(x => x.Journal, y => y.MapFrom(z => z.Journal))
                .ForMember(x => x.Subscriber, y => y.MapFrom(z => z.Subscriber));
        }
    }
}

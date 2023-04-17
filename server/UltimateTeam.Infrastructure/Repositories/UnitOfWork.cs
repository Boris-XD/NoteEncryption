using System.Threading.Tasks;
using Dev33.UltimateTeam.Application.Contracts.Repositories;
using Dev33.UltimateTeam.Infrastructure.Context;
using UltimateTeam.Application.Contracts.Repositories;
using UltimateTeam.Infrastructure.Repositories;

namespace Dev33.UltimateTeam.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SafeInformationDBContext context;

        public UnitOfWork(SafeInformationDBContext context)
        {
            this.context = context;
        }

        public ICreditCardRepository CreditCardRepository => new CreditCardRepository(context);

        public IUserRepository UserRepository => new UserRepository(context);

        public IContainerRepository ContainerRepository => new ContainerRepository(context);

        public IInformationRepository InformationRepository => new InformationRepository(context);

        public INoteRepository NoteRepository => new NoteRepository(context);

        public ITagRepository TagRepository => new TagRepository(context);

        public IKeyRepository KeyRepository => new KeyRepository(context);

        public IContactRepository ContactRepository => new ContactRepository(context);

        public IAddressRepository AddressRepository => new AddressRepository(context);

        public IPhoneRepository PhoneRepository => new PhoneRepository(context);

        public IEmailRepository EmailRepository => new EmailRepository(context);

        public IUrlRepository UrlRepository => new UrlRepository(context);

        public ICredentialRepository CredentialRepository => new CredentialRepository(context);

        public IShareInformationRepository shareInformationRepository => new ShareInformationRepository(context);

        public async Task SaveChangesAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}
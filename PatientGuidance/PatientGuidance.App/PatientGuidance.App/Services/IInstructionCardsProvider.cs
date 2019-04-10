using System.Collections.Generic;
using System.Threading.Tasks;
using PatientGuidance.App.Common;

namespace PatientGuidance.App.Services
{
    public interface IInstructionCardsProvider
    {
        Task<IEnumerable<Card>> GetRelevantCardsAsync();
    }

    internal class StaticCardsProvider : IInstructionCardsProvider
    {
        public Task<IEnumerable<Card>> GetRelevantCardsAsync()
            => Task.Run(() => new List<Card>
            {
                new Card
                {
                    Type = CardType.Default
                },
                new Card
                {
                    Type = CardType.Default
                },
                new Card
                {
                    Type = CardType.ComplexGastro
                }
            } as IEnumerable<Card>);
    }
}

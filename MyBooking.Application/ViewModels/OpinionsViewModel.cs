using System.Collections.Generic;
using System.Linq;
using MyBooking.Core.Dtos;

namespace MyBooking.Application.ViewModels
{
    public class OpinionsViewModel
    {
        public IEnumerable<OpinionDto> Opinions { get; private set; }

        public CreateOpinionDto Input { get; }

        public OpinionsViewModel(IEnumerable<OpinionDto> opinions, CreateOpinionDto input)
        {
            Opinions = opinions;
            Input = input;
        }

        public void SortOpinions()
        {
            Opinions = Opinions.OrderByDescending(o => o.DateCreated);
        }
    }
}
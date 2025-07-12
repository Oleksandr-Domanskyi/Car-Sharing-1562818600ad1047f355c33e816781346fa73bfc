using CarSharingApplication.DataTransferObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarSharingApplication.CarSharing.CarSharingProfile.Queries.GetBySearchName
{
    public class GetBySearchNameCarSharingQuery:IRequest<IEnumerable<ShowCarSharingProfileModelObject>>
    {
        public GetBySearchNameCarSharingQuery(string search)
        {
            Search = search;
        }
        public string Search {  get; set; }
    }
}

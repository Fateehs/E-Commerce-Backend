﻿using MediatR;

namespace ETradeAPI.Application.Features.Queries.Order.GetAllOrder
{
    public class GetAllOrdersQueryRequest : IRequest<GetAllOrdersQueryResponse>
    {
        public int Page { get; set; } = 0;
        public int Size { get; set; } = 5;
    }
}
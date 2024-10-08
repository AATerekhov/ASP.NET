﻿using AutoFixture.AutoMoq;
using AutoFixture;
using AutoFixture.Xunit2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PromoCodeFactory.WebHost.Controllers;
using Microsoft.AspNetCore.Mvc.Filters;
using PromoCodeFactory.Core.Domain.PromoCodeManagement;
using PromoCodeFactory.WebHost.Models.Request;
using AutoFixture.Kernel;
using System.Reflection;

namespace PromoCodeFactory.UnitTests.Helps
{
    public class AutoMoqDataAttribute:AutoDataAttribute
    {
        public AutoMoqDataAttribute() : base(fixtureFactory: fixtureFactory)
        { }

        private static readonly Func<IFixture> fixtureFactory = () =>
        {
            var fixture = new Fixture().Customize(new AutoMoqCustomization());
            fixture.Customize<PartnersController>(c => c.OmitAutoProperties());
            fixture.Customize<Partner>(c => c.With(x => x.IsActive, true));
            fixture.Customize<PartnerPromoCodeLimit>(c => c.Without(x => x.Partner).Without(x=> x.PartnerId));
            fixture.Customize<SetPartnerPromoCodeLimitRequest>(c => c.FromFactory(new PartnerPromoCodeLimitBuilder()));
            return fixture;
        }; 
    }
}

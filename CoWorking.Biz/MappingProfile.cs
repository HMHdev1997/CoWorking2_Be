using AutoMapper;
using CoWorking.Biz.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            #region Area
            CreateMap<Data.Model.Area, Model.Area.New>().ReverseMap();
            CreateMap<Data.Model.Area, Model.Area.View>().ReverseMap();
            CreateMap<Data.Model.Area, Model.Area.Edit>().ReverseMap();
            #endregion

            #region Customer
            //CreateMap<Data.Model.Customer, Model.Customers.Edit>().ReverseMap();
            CreateMap<Data.Model.Customer, Model.Customers.View>().ReverseMap();
            #endregion

            CreateMap<Data.Model.CategoryOffice, Model.CategoryOffice.New>().ReverseMap();
            CreateMap<Data.Model.CategoryOffice, Model.CategoryOffice.View>().ReverseMap();
            CreateMap<Data.Model.CategoryOffice, Model.CategoryOffice.Edit>().ReverseMap();
            CreateMap<Data.Model.CategoryOffice, Model.CategoryOffice.Filter>().ReverseMap();
            CreateMap<Data.Model.CategoryOffice, Model.CategoryOffice.CategoryOfficeView>().ReverseMap();

            CreateMap<Data.Model.CategoryService, Model.CategoryService.Edit>().ReverseMap();
            CreateMap<Data.Model.CategoryService, Model.CategoryService.New>().ReverseMap();
            CreateMap<Data.Model.CategoryService, Model.CategoryService.View>().ReverseMap();
            

            CreateMap<Data.Model.CategorySpace, Model.CategorySpace.New>().ReverseMap();
            CreateMap<Data.Model.CategorySpace, Model.CategorySpace.View>().ReverseMap();

            CreateMap<Data.Model.CategorySpace, Model.CategorySpace.New>().ReverseMap();
            CreateMap<Data.Model.CategorySpace, Model.CategorySpace.View>().ReverseMap();

            CreateMap<Data.Model.FeedBack, Model.FeedBack.New>().ReverseMap();
            CreateMap<Data.Model.FeedBack, Model.FeedBack.View>().ReverseMap();

            #region Office
            CreateMap<Data.Model.Office, Model.Offices.Filer>().ReverseMap();
            CreateMap<Data.Model.Office, Model.Offices.View>().ReverseMap();
            #endregion

            CreateMap<Data.Model.OfficeImage, Model.OfficeImages.View>().ReverseMap();
            CreateMap<Data.Model.OfficeImage, Model.OfficeImages.New>().ReverseMap();

            CreateMap<Data.Model.FeedBack, Model.FeedBack.New>().ReverseMap();
            CreateMap<Data.Model.FeedBack, Model.FeedBack.Edit>().ReverseMap();
            CreateMap<Data.Model.FeedBack, Model.FeedBack.View>().ReverseMap();

            CreateMap<Data.Model.Booking, Model.Bookings.New>().ReverseMap();
            CreateMap<Data.Model.Booking, Model.Bookings.View>().ReverseMap();

            CreateMap<Data.Model.BookingDetail, Model.BookingDetail.New>().ReverseMap();
            CreateMap<Data.Model.BookingDetail, Model.BookingDetail.View>().ReverseMap();

            CreateMap<Data.Model.User, Model.User.New>().ReverseMap();
            CreateMap<Data.Model.User, Model.User.View>().ReverseMap();


            CreateMap<Data.Model.OfficeImage, Model.OfficeImages.View>().ReverseMap();

            CreateMap<Data.Model.Booking, Model.Bookings.New>().ReverseMap();
            CreateMap<Data.Model.Booking, Model.Bookings.View>().ReverseMap();

            #region OfficeInCategory
            CreateMap<Data.Model.OfficeInCategory, Model.OfficeInCategory.New>().ReverseMap();
            CreateMap<Data.Model.OfficeInCategory, Model.OfficeInCategory.View>().ReverseMap();
            #endregion

        }
    }
}

using AutoMapper;
using CoWorking.Biz.Model.FeedBack;
using CoWorking.Data.Access;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoWorking.Biz.FeedBack
{
    public class Repository : IRepository
    {
        private readonly DomainDbContext _context;
        private readonly IMapper _mapper;
   
        public Repository(DomainDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
          
        }

        public async Task<Model.FeedBack.View> CreateAsync(Model.FeedBack.New request)
        {
            var item = _mapper.Map<Model.FeedBack.New, Data.Model.FeedBack>(request);
            await _context.FeedBacks.AddAsync(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.FeedBack, Model.FeedBack.View>(item);

        }

        public async Task Delete(int id)
        {
            var item = _context.FeedBacks.FirstOrDefault(x => x.ID == id);
            _context.FeedBacks.RemoveRange(item);
            await _context.SaveChangesAsync();
        }

        public async Task<View> Update(Edit request)
        {
            var feedBack = await _context.FeedBacks.FindAsync(request.ID);
            var item =  _mapper.Map( request, feedBack);
             _context.FeedBacks.Update(item);
            await _context.SaveChangesAsync();
            return _mapper.Map<Data.Model.FeedBack, View>(item);

        }
    }
}

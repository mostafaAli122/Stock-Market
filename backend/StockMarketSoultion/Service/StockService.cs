using Domain_.Entities;
using Infrastructure.Interfaces;

namespace Service
{
    public class StockService
    {
        private readonly IUnitOfWork _unitOfWork;

        public StockService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public List<Stock> GetStocks()
        {
            return _unitOfWork.StockRepository.GetAllStocks().ToList();
        }
        public  Stock GetStockById(int id)
        {
            return _unitOfWork.StockRepository.GetById(id);
        }
        public void SaveChanges()
        {
            _unitOfWork.SaveChanges();
        }
    }

}

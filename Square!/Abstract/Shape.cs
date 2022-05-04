using System;
using System.Threading.Tasks;

namespace Square_.Abstract
{
    public abstract class Shape
    {
        private readonly Lazy<double> _square;

        /// <summary>
        /// Площадь фигуры
        /// </summary>
        public double Square => _square.Value;
        
        public Shape()
        {
            _square = new Lazy<double>(GetSquare);
        }

        public abstract Task<double> GetSquareAsync();
        public abstract double GetSquare();
    }
}

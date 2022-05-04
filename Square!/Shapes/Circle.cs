using Square_.Abstract;
using System;
using System.Threading.Tasks;

namespace Square_.Shapes
{
    public class Circle : Shape
    {
        /// <summary>
        /// Радиус
        /// </summary>
        public double Radius { get; }

        /// <summary>
        /// Окружность
        /// </summary>
        /// <param name="radius"></param>
        /// <exception cref="ArgumentException">Если радиус отрицательный</exception>
        public Circle(double radius)
        {
            if (radius < 0)
                throw new ArgumentOutOfRangeException("Radius can not be smaller than 0", nameof(radius));

            Radius = radius;
        }

        /// <summary>
        /// Площадь
        /// </summary>
        /// <returns></returns>
        public override double GetSquare() => Math.PI * Math.Pow(Radius, 2);


        /// <summary>
        /// Площадь async
        /// </summary>
        /// <returns></returns>
        public override async Task<double> GetSquareAsync() => await Task.FromResult(GetSquare());
    }
}
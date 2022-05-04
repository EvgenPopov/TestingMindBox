using Square_.Abstract;
using System;
using System.Threading.Tasks;

namespace Square_.Shapes
{
    public class Triangle : Shape
    {
        /// <summary>
        /// первая сторона
        /// </summary>
        public double FirstSide { get; }

        /// <summary>
        /// вторая сторона
        /// </summary>
        public double SecondSide { get; }

        /// <summary>
        /// третья сторона
        /// </summary>
        public double ThirdSide { get; }

        /// <summary>
        /// является ли треугольник прямоугольным
        /// </summary>
        public bool IsRightTriangle { get; }


        /// <summary>
        /// Треугольник
        /// </summary>
        /// <param name="firstSide">первая сторона</param>
        /// <param name="secondSide">вторая сторона</param>
        /// <param name="thirdSide">третья сторона</param>
        /// <exception cref="ArgumentOutOfRangeException">Если сторона имеет отрицательное значие, или неправильно указаны стороны треугольника</exception>
        public Triangle(double firstSide, double secondSide, double thirdSide)
        {

            if (firstSide < 0)
                throw new ArgumentOutOfRangeException($"side is incorrect {nameof(firstSide)}");
            if (secondSide < 0)
                throw new ArgumentOutOfRangeException($"side is incorrect {nameof(firstSide)}");
            if (thirdSide < 0)
                throw new ArgumentOutOfRangeException($"side is incorrect {nameof(firstSide)}");

            FirstSide = firstSide;
            SecondSide = secondSide;
            ThirdSide = thirdSide;

            if (!IsTriangleValid())
                throw new ArgumentOutOfRangeException("The sides of the triangle are wrong");

            IsRightTriangle = IsRight();
        }

        private bool IsRight()
        {
            double hypo = FirstSide, firstLeg = SecondSide, secondLeg = ThirdSide;

            if (firstLeg - hypo > 0)
                (hypo, firstLeg) = (firstLeg, hypo);

            if (secondLeg - hypo > 0)
                (hypo, secondLeg) = (secondLeg, hypo);

            return Math.Abs(Math.Pow(hypo, 2) - Math.Pow(firstLeg, 2) - Math.Pow(secondLeg, 2)) == 0;

        }

        /// <summary>
        /// Проверка на валидность указанный сторон
        /// </summary>
        /// <returns></returns>
        private bool IsTriangleValid()
        {
            var maxSide = Math.Max(FirstSide, Math.Max(SecondSide, ThirdSide));
            var perimeter = GetPerimeter();

            return (perimeter - maxSide) - maxSide > 0.00;
        }

        /// <summary>
        /// Вычислить периметр треугольника
        /// </summary>
        /// <returns></returns>
        private double GetPerimeter() => FirstSide + SecondSide + ThirdSide;


        /// <summary>
        /// Площадь async
        /// </summary>
        /// <returns></returns>
        public override Task<double> GetSquareAsync() => Task.FromResult(GetSquare());


        /// <summary>
        /// Площадь
        /// </summary>
        /// <returns></returns>
        public override double GetSquare()
        {
            double semiPerimeter = GetPerimeter() / 2;

            return Math.Sqrt(semiPerimeter * (semiPerimeter-FirstSide) * (semiPerimeter-SecondSide) * (semiPerimeter-ThirdSide));
        }



    }
}

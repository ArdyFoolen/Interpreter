using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RomanInterpreter
{
    public class RomanBuilder : IRomanBuilder
    {
        private IRoman previous;
        private RomanEnum maxToken = RomanEnum.M;
        private RomanEnum previousToken = RomanEnum.M;
        private RomanEnum newToken;

        public IRomanBuilder WithToken(char token)
        {
            GuardAgainstToken(token);

            INumberRoman roman = new NumberRoman(newToken);
            CreateAddSubtractRoman(roman);

            return this;
        }

        public IRoman Build()
            => previous;

        private void CreateAddSubtractRoman(INumberRoman roman)
        {
            if (previous == null)
                previous = roman;
            else if (previous.IsSmaller(roman))
                previous = new SubtractRoman(previous, roman);
            else
                previous = new AddRoman(previous, roman);
        }

        private void GuardAgainstToken(char token)
        {
            ConvertToEnum(token);

            if (newToken > maxToken)
                throw new RomanNotAllowedException(newToken);

            SetMaxTokenIfRepeating();
            SetMaxTokenBelowIfFive();
            SetMaxTokenBelowIfSubtract();

            previousToken = newToken;
        }

        private void SetMaxTokenBelowIfSubtract()
        {
            if (previousToken < newToken &&
                previousToken.IsSpecificRoman<RomanOneEnum>())
                maxToken = previousToken.Minus();
        }

        private void SetMaxTokenBelowIfFive()
        {
            if (newToken.IsSpecificRoman<RomanFiveEnum>())
                maxToken = newToken.Minus();
        }

        private void SetMaxTokenIfRepeating()
        {
            if (newToken == previousToken)
                maxToken = newToken;
        }

        private void ConvertToEnum(char token)
            => newToken = token.ToEnum<RomanEnum>();
    }
}

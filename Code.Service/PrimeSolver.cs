using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Code.Service
{
    public class PrimeSolver
    {
        // this could be assigned Array.MaxLength to find more primes
        // but for the sample we will asign 1000
        private const int MAX = 1000; 

        // we are using a array simulation like a cache
        // TRUE value will be set for prime numbers
        private bool[] _numbers = new bool[MAX];

        // once the primes are identify this flag will be turn on
        private bool _isProcessed = false;
        
        public IEnumerable<int> GetPrimes(int startNumber, int n)
        {
            var selectedPrimes = new List<int>();
            
            //input validation
            if(startNumber < 0) return selectedPrimes;
            if(n < 0) return selectedPrimes;

            if (!_isProcessed)
                ProcessNumbers();
                        
            int count = 0; // counter for first n primes
            int index = startNumber; // index where starts to count

            while(count < n && index < _numbers.Length)
            {
                if (_numbers[index])
                {
                    count++;
                    selectedPrimes.Add(index);
                }

                index++;
            }

            return selectedPrimes;
        }

        // iterate over numbers and mark all no primes
        private void ProcessNumbers()
        {
            for (int i = 0; i < _numbers.Length; i++)
                _numbers[i] = true;

            _numbers[0] = false;
            _numbers[1] = false;

            for (int i = 2; i * i <= _numbers.Length; i++)
            {
                // skip if number is no prime
                if (_numbers[i] == true)
                {
                    // Set all multiples of number i to non-prime
                    for (int j = i * 2; j < _numbers.Length; j += i)
                        _numbers[j] = false;
                }
            }

            _isProcessed = true;
        }
    }
}

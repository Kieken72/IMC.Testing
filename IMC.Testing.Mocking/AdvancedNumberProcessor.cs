using System;
using System.Collections.Generic;
using System.Linq;

namespace IMC.Testing.Mocking
{
    public class AdvancedNumberProcessor
    {
        private readonly IExternalFileShareRepository _externalFileShareRepository;


        public AdvancedNumberProcessor(IExternalFileShareRepository externalFileShareRepository)
        {
            _externalFileShareRepository = externalFileShareRepository;
        }

        public OverviewModel GetReport()
        {
            var allItems = _externalFileShareRepository.GetAllItems();

            var numbers = allItems.Select(str => {
                int value;
                bool success = int.TryParse(str, out value);
                return new { value, success };
            })
                .Where(pair => pair.success)
                .Select(pair => pair.value);

            return new OverviewModel { NumberCount = numbers.Count(), Average = numbers.Average() };
        }

        public void DoProcessing()
        {
            IEnumerable<string> batch;
            var output = new List<string>();

            try
            {
                batch = _externalFileShareRepository.GetAllItems();
            }
            catch (Exception e)
            {
                throw new Exception("Sorry user, something went wrong while getting the data!");
            }

            foreach (var batchItem in batch)
            {
                int value;
                bool isNumber = int.TryParse(batchItem, out value);

                if (isNumber)
                {
                    value = value + 1;

                    if (value == 13)
                    {
                        throw new ArgumentException("Boem 13!");
                    }

                    output.Add(value.ToString());
                }
                else
                {
                    output.Add(batchItem + "a");
                }
            }
            _externalFileShareRepository.Save(output);
        }
    }

    // External service
}

using System;
using ApiAiSDK;

namespace ConsoleApiAiBot
{
    class Program
    {
        private const string ClientAccessToken = "14211a3397f74849a620713480c2df19";

        static void Main(string[] args)
        {
            Console.Title = "Console-ApiAi-Bot";

            for (;;)
            {
                Console.Clear();
                Console.Write("Введите запрос: ");

                var responseString = Console.ReadLine();

                if (String.IsNullOrWhiteSpace(responseString))
                {
                    Console.WriteLine("\nНапишите, пожалуйста, Ваш запрос!");
                    Console.ReadLine();
                    continue;
                }

                // Конфигурация агента Api.ai
                var config = new AIConfiguration(ClientAccessToken, SupportedLanguage.Russian);
                var apiAi = new ApiAi(config);

                // Ответ
                var response = apiAi.TextRequest(responseString);
                if (response == null) continue;

                Console.WriteLine("Ответ: {0}", response.Result.Fulfillment.Speech);

                Console.ReadLine();
            }
        }
    }
}

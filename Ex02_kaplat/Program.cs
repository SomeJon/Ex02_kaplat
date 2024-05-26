using System.Net.Http.Json;


namespace Ex02_kaplat
{
    public class Program
    {
        public async static Task Main()
        {
            string response1;
            MessageObj response2;
            MessageObj response3;
            string baseUrl = "http://localhost:6767/";


            response1 = await sendDataUsingQueryParamters(baseUrl);
            Question2Body que2Body = new Question2Body(208230631, 1999, response1);
            response2 = await sendingDataToTheServerUsingABody(baseUrl, que2Body);
            Question3Body que3Body
                = new Question3Body(((que2Body.Id - 123503) % 92), ((que2Body.Year + 123) % 45));
            response3 = await updateDataInServer(baseUrl, new MessageObj(response2.Message), que3Body);
            await deleteDataInServer(baseUrl, response3);
        }


        private async static Task<string> sendDataUsingQueryParamters(string i_BaseUrl)
        {
            string url = i_BaseUrl + "test_get_method?id=208230631&year=1999";
            string response;

            using (HttpClient client = new HttpClient())
            {
                response = await client.GetStringAsync(url);
            }

            return response;
        }


        private async static Task<MessageObj> sendingDataToTheServerUsingABody
            (string i_BaseUrl, Question2Body i_Body)
        {
            string url = i_BaseUrl + "test_post_method";
            MessageObj? returnMessage;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PostAsJsonAsync<Question2Body>(url, i_Body);
                returnMessage = await response.Content.ReadFromJsonAsync<MessageObj>();
            }

            return returnMessage;
        }


        private async static Task<MessageObj> updateDataInServer
            (string i_BaseUrl, MessageObj i_Message, Question3Body i_Body)
        {
            string url = i_BaseUrl + "test_put_method?id=" + i_Message.Message;
            MessageObj? returnMessage;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.PutAsJsonAsync<Question3Body>(url, i_Body);
                returnMessage = await response.Content.ReadFromJsonAsync<MessageObj>();
            }

            return returnMessage;
        }


        private async static Task deleteDataInServer(string i_BaseUrl, MessageObj i_Message)
        {
            string url = i_BaseUrl + "test_delete_method?id=" + i_Message.Message;
            MessageObj? returnMessage;

            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.DeleteAsync(url);
                returnMessage = await response.Content.ReadFromJsonAsync<MessageObj>();
            }
        }
    }
}

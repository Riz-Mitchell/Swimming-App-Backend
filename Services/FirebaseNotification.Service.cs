// using Newtonsoft.Json;
// using System.Net.Http;
// using System.Text;
// using System.Threading.Tasks;

// namespace SwimmingAppBackend.Services
// {
//     public class FirebaseNotificationService
//     {
//         private readonly string _firebaseServerKey;
//         private readonly HttpClient _httpClient;

//         public FirebaseNotificationService(string firebaseServerKey)
//         {
//             _firebaseServerKey = firebaseServerKey;
//             _httpClient = new HttpClient();
//         }

//         public async Task<bool> SendNotificationAsync(string deviceToken, string title, string body)
//         {
//             // Firebase Cloud Messaging (FCM) URL for sending messages
//             var url = "https://fcm.googleapis.com/fcm/send";

//             // Prepare the notification payload
//             var message = new
//             {
//                 to = deviceToken,  // The device token to send the notification to
//                 notification = new
//                 {
//                     title = title,
//                     body = body,
//                     sound = "default"
//                 },
//                 priority = "high"
//             };

//             // Serialize the message to JSON
//             var jsonMessage = JsonConvert.SerializeObject(message);

//             // Create the HTTP request
//             var request = new HttpRequestMessage(HttpMethod.Post, url)
//             {
//                 Headers = {
//                 { "Authorization", $"key={_firebaseServerKey}" }
//             },
//                 Content = new StringContent(jsonMessage, Encoding.UTF8, "application/json")
//             };

//             // Send the request to Firebase
//             var response = await _httpClient.SendAsync(request);

//             // Check if the response is successful
//             return response.IsSuccessStatusCode;
//         }
//     }
// }
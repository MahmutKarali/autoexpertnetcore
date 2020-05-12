using FireSharp.Config;
using FireSharp.Interfaces;
using FireSharp.Response;

namespace WebAPI
{
    public class FirebaseConnection
    {
        public IFirebaseConfig config = new FirebaseConfig
        {
            AuthSecret = "6v8aurdRvVSd3cK0jhaX7ejpPtHk6LRxV96bjolh",
            BasePath = "https://autoexpertise-21b19.firebaseio.com"
        };

        public IFirebaseConfig client;
        public FirebaseResponse response;
    }
}

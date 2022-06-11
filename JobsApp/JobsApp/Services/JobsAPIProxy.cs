using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using JobsApp.Models;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.Unicode;
using System.Text.Encodings.Web;
using Xamarin.Forms;
using Xamarin.Essentials;
using System.IO;


namespace JobsApp.Services
{
    class JobsAPIProxy
    {
        private const string CLOUD_URL = "TBD"; //API url when going on the cloud
        private const string CLOUD_PHOTOS_URL = "TBD";
        private const string DEV_ANDROID_EMULATOR_URL = "http://10.0.2.2:27556/iJobAPI"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_URL = "http://192.168.1.14:27556/iJobAPI"; //API url when using physical device on android
        private const string DEV_WINDOWS_URL = "http://localhost:27556/iJobAPI"; //API url when using windoes on development
        private const string DEV_ANDROID_EMULATOR_PHOTOS_URL = "http://10.0.2.2:27556/Images/"; //API url when using emulator on android
        private const string DEV_ANDROID_PHYSICAL_PHOTOS_URL = "http://192.168.1.14:27556/Images/"; //API url when using physucal device on android
        private const string DEV_WINDOWS_PHOTOS_URL = "http://localhost:27556/Images/"; //API url when using windoes on development

        private HttpClient client;
        private string baseUri;
        private string basePhotosUri;
        private static JobsAPIProxy proxy = null;

        public static JobsAPIProxy CreateProxy()
        {
            string baseUri;
            string basePhotosUri;
            if (App.IsDevEnv)
            {
                if (Device.RuntimePlatform == Device.Android)
                {
                    if (DeviceInfo.DeviceType == DeviceType.Virtual)
                    {
                        baseUri = DEV_ANDROID_EMULATOR_URL;
                        basePhotosUri = DEV_ANDROID_EMULATOR_PHOTOS_URL;
                    }
                    else
                    {
                        baseUri = DEV_ANDROID_PHYSICAL_URL;
                        basePhotosUri = DEV_ANDROID_PHYSICAL_PHOTOS_URL;
                    }
                }
                else
                {
                    baseUri = DEV_WINDOWS_URL;
                    basePhotosUri = DEV_WINDOWS_PHOTOS_URL;
                }
            }
            else
            {
                baseUri = CLOUD_URL;
                basePhotosUri = CLOUD_PHOTOS_URL;
            }

            if (proxy == null)
                proxy = new JobsAPIProxy(baseUri, basePhotosUri);
            return proxy;
        }


        private JobsAPIProxy(string baseUri, string basePhotosUri)
        {
            //Set client handler to support cookies!!
            HttpClientHandler handler = new HttpClientHandler();
            handler.CookieContainer = new System.Net.CookieContainer();

            //Create client with the handler!
            this.client = new HttpClient(handler, true);
            this.baseUri = baseUri;
            this.basePhotosUri = basePhotosUri;
        }

        public string GetBasePhotoUri() { return this.basePhotosUri; }

        //Example function

        public async Task<string> ExFuncAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/Time");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                   
                    return content;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Login!
        public async Task<User> LoginAsync(string email, string pass)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/Login?email={email}&pass={pass}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    User e = JsonSerializer.Deserialize<User>(content, options);
                    return e;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<User> SignUpAsync(User u)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.Hebrew, UnicodeRanges.BasicLatin),
                    PropertyNameCaseInsensitive = true
                };
                string jsonObject = JsonSerializer.Serialize<User>(u, options);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/SignUp", content);
                if (response.IsSuccessStatusCode)
                {
                    options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string contentU = await response.Content.ReadAsStringAsync();
                    User e = JsonSerializer.Deserialize<User>(contentU, options);
                    return e;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> IsExistNickNameAsync(string nickname)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/IsNickNameExist?nickname={nickname}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    bool b = JsonSerializer.Deserialize<bool>(content, options);
                    return b;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<bool> IsEmailExistAsync(string email)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/IsEmailExist?email={email}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    bool b = JsonSerializer.Deserialize<bool>(content, options);
                    return b;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<List<Category>> GetCategories()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetCategories");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<Category> b = JsonSerializer.Deserialize<List<Category>>(content, options);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<JobOffer>> GetAllJobOffersAsync(int employerID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetJobOffers?employerID={employerID}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<JobOffer> b = JsonSerializer.Deserialize<List<JobOffer>>(content, options);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<List<JobOffer>> GetJobOfferEmployeesAsync(int JobOfferID)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetJobOfferEmployees?JobOfferId={JobOfferID}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    List<JobOffer> b = JsonSerializer.Deserialize<List<JobOffer>>(content, options);
                    return b;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<bool> IsPetNameExistAsync(string email, string petName)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/IsPetNameExist?email={email}&petName={petName}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    bool b = JsonSerializer.Deserialize<bool>(content, options);
                    return b;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<User> GetUserAsync(string email)
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetUser?email={email}");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    User e = JsonSerializer.Deserialize<User>(content, options);
                    return e;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        //Upload file to server (only images!)
        public async Task<bool> UploadImage(Models.FileInfo fileInfo, string targetFileName)
        {
            try
            {
                var multipartFormDataContent = new MultipartFormDataContent();
                var fileContent = new ByteArrayContent(File.ReadAllBytes(fileInfo.Name));
                multipartFormDataContent.Add(fileContent, "file", targetFileName);
                HttpResponseMessage response = await client.PostAsync($"{this.baseUri}/UploadImage", multipartFormDataContent);
                if (response.IsSuccessStatusCode)
                {
                    return true;
                }
                else
                    return false;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
        }

        public async Task<LookUps> GetLookupsAsync()
        {
            try
            {
                HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetLookups");
                if (response.IsSuccessStatusCode)
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string content = await response.Content.ReadAsStringAsync();
                    LookUps obj = JsonSerializer.Deserialize<LookUps>(content, options);
                    return obj;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<JobOffer> AddJobOfferAsync(JobOffer jobOffer)
        {
            try
            {
                JsonSerializerOptions options = new JsonSerializerOptions
                {
                    ReferenceHandler = ReferenceHandler.Preserve,
                    Encoder = JavaScriptEncoder.Create(UnicodeRanges.Hebrew, UnicodeRanges.BasicLatin),//Remove
                    PropertyNameCaseInsensitive = true
                };
                string jsonObject = JsonSerializer.Serialize<JobOffer>(jobOffer, options);
                StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/AddJobOffer", content);
                if (response.IsSuccessStatusCode)
                {
                    options = new JsonSerializerOptions
                    {
                        ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
                        PropertyNameCaseInsensitive = true
                    };
                    string contentU = await response.Content.ReadAsStringAsync();
                    JobOffer j = JsonSerializer.Deserialize<JobOffer>(contentU, options);
                    return j;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }



        //public async Task<bool> ChangePassAsync(string email, string newPass)
        //{
        //    try
        //    {
        //        HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/ChangePass?email={email}&pass={newPass}");
        //        if (response.IsSuccessStatusCode)
        //        {
        //            JsonSerializerOptions options = new JsonSerializerOptions
        //            {
        //                ReferenceHandler = ReferenceHandler.Preserve, //avoid reference loops!
        //                PropertyNameCaseInsensitive = true
        //            };
        //            string content = await response.Content.ReadAsStringAsync();
        //            User e = JsonSerializer.Deserialize<User>(content, options);
        //            return e;
        //        }
        //        else
        //        {
        //            return null;
        //        }
        //    }
        //    catch (Exception e)
        //    {
        //        Console.WriteLine(e.Message);
        //        return null;
        //    }
        //}



    }
}


////Get the list of phone types
//public async Task<List<PhoneType>> GetPhoneTypesAsync()
//{
//    try
//    {

//        HttpResponseMessage response = await this.client.GetAsync($"{this.baseUri}/GetPhoneTypes");
//        if (response.IsSuccessStatusCode)
//        {
//            JsonSerializerOptions options = new JsonSerializerOptions
//            {
//                ReferenceHandler = ReferenceHandler.Preserve,
//                PropertyNameCaseInsensitive = true
//            };
//            string content = await response.Content.ReadAsStringAsync();
//            List<PhoneType> eList = JsonSerializer.Deserialize<List<PhoneType>>(content, options);
//            return eList;
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//        return null;
//    }
//}

//public async Task<UserContact> UpdateContact(UserContact uc)
//{
//    try
//    {
//        JsonSerializerOptions options = new JsonSerializerOptions
//        {
//            ReferenceHandler = ReferenceHandler.Preserve,
//            Encoder = JavaScriptEncoder.Create(UnicodeRanges.Hebrew, UnicodeRanges.BasicLatin),
//            PropertyNameCaseInsensitive = true
//        };
//        string jsonObject = JsonSerializer.Serialize<UserContact>(uc, options);
//        StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/UpdateContact", content);
//        if (response.IsSuccessStatusCode)
//        {
//            string jsonContent = await response.Content.ReadAsStringAsync();
//            UserContact ret = JsonSerializer.Deserialize<UserContact>(jsonContent, options);

//            return ret;
//        }
//        else
//        {
//            return null;
//        }
//    }
//    catch (Exception ee)
//    {
//        Console.WriteLine(ee.Message);
//        return null;
//    }
//}

//public async Task<bool> RemoveContact(UserContact uc)
//{
//    try
//    {
//        JsonSerializerOptions options = new JsonSerializerOptions
//        {
//            ReferenceHandler = ReferenceHandler.Preserve,
//            Encoder = JavaScriptEncoder.Create(UnicodeRanges.Hebrew, UnicodeRanges.BasicLatin),
//            PropertyNameCaseInsensitive = true
//        };
//        string jsonObject = JsonSerializer.Serialize<UserContact>(uc, options);
//        StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/RemoveContact", content);
//        if (response.IsSuccessStatusCode)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//    catch (Exception ee)
//    {
//        Console.WriteLine(ee.Message);
//        return false;
//    }
//}

//public async Task<bool> RemoveContactPhone(Models.ContactPhone cp)
//{
//    try
//    {
//        JsonSerializerOptions options = new JsonSerializerOptions
//        {
//            ReferenceHandler = ReferenceHandler.Preserve,
//            Encoder = JavaScriptEncoder.Create(UnicodeRanges.Hebrew, UnicodeRanges.BasicLatin),
//            PropertyNameCaseInsensitive = true
//        };
//        string jsonObject = JsonSerializer.Serialize<Models.ContactPhone>(cp, options);
//        StringContent content = new StringContent(jsonObject, Encoding.UTF8, "application/json");

//        HttpResponseMessage response = await this.client.PostAsync($"{this.baseUri}/RemoveContactPhone", content);
//        if (response.IsSuccessStatusCode)
//        {
//            return true;
//        }
//        else
//        {
//            return false;
//        }
//    }
//    catch (Exception ee)
//    {
//        Console.WriteLine(ee.Message);
//        return false;
//    }
//}

////Upload file to server (only images!)
//public async Task<bool> UploadImage(Models.FileInfo fileInfo, string targetFileName)
//{
//    try
//    {
//        var multipartFormDataContent = new MultipartFormDataContent();
//        var fileContent = new ByteArrayContent(File.ReadAllBytes(fileInfo.Name));
//        multipartFormDataContent.Add(fileContent, "file", targetFileName);
//        HttpResponseMessage response = await client.PostAsync($"{this.baseUri}/UploadImage", multipartFormDataContent);
//        if (response.IsSuccessStatusCode)
//        {
//            return true;
//        }
//        else
//            return false;
//    }
//    catch (Exception e)
//    {
//        Console.WriteLine(e.Message);
//        return false;
//    }
//}



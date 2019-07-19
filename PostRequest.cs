namespace func_swagger_test
{
    public class PostRequest
    {
        [MinMax("x-min", "5")]
        [MinMax("x-max", "255")]
        public string Stuff { get; set; }
        public string OtherStuff { get; set; }
    }
}
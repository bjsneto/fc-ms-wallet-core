using System.Text.Json.Serialization;

namespace Balance.App.Model
{
    public class Balance
    {
        public string Name { get; set; }
        public Payload Payload { get; set; }
    }

    public class Payload
    {
        [JsonPropertyName("account_id_from")]
        public string AccountIdFrom { get; set; }

        [JsonPropertyName("account_id_to")]
        public string AccountIdTo { get; set; }

        [JsonPropertyName("balance_account_id_from")]
        public int BalanceAccountIdFrom { get; set; }

        [JsonPropertyName("balance_account_id_to")]
        public int BalanceAccountIdTo { get; set; }
    }
}

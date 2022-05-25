// See https://aka.ms/new-console-template for more information
using Confluent.Kafka;

Console.WriteLine("Hello, World!");

var configProducer = new ProducerConfig()
{
    BootstrapServers = "tricycle-01.srvs.cloudkafka.com:9094,tricycle-02.srvs.cloudkafka.com:9094,tricycle-03.srvs.cloudkafka.com:9094",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.ScramSha256,
    SaslUsername = "l2gu7ibo",
    SaslPassword = "eg6etvHq9SDqkqyMfKxoPldKvH_4Mtvk"
};
var configConsumer = new ConsumerConfig()
{
    BootstrapServers = "tricycle-01.srvs.cloudkafka.com:9094,tricycle-02.srvs.cloudkafka.com:9094,tricycle-03.srvs.cloudkafka.com:9094",
    SecurityProtocol = SecurityProtocol.SaslSsl,
    SaslMechanism = SaslMechanism.ScramSha256,
    SaslUsername = "l2gu7ibo",
    SaslPassword = "eg6etvHq9SDqkqyMfKxoPldKvH_4Mtvk",

    GroupId = "l2gu7ibo-consumer",
    AutoOffsetReset = AutoOffsetReset.Latest
};

string topic = "l2gu7ibo-fiap";

//await KafkaProducer(configProducer, topic);
KafkaConsumer(configConsumer, topic);

static async Task KafkaProducer(ProducerConfig config, string topic)
{
    string nome = "rela";

    var builder = new ProducerBuilder<string, string>(config);

    using (var producer = builder.Build())
    {
        for (int i = 0; i < 10; i++)
        {
            var message = new Message<string, string>
            {
                Key = nome,
                Value = "Mensagem de " + nome + " : " + i
            };

            await producer.ProduceAsync(topic, message);
        }
    }

}

static void KafkaConsumer(ConsumerConfig config, string topic)
{
    int count = 0;

    var builder = new ConsumerBuilder<string, string>(config);

    using (var consumer = builder.Build())
    {
        consumer.Subscribe(topic);

        while (true)
        {
            var result = consumer.Consume(TimeSpan.FromSeconds(1));

            if (result != null)
            {
                string texto = result.Message.Value;

                int part = result.Partition.Value;

                Console.WriteLine($"{count++}: recebido {texto} (Particao: {part})");
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Laba3;

class FileSerializer
{
    public ObservableCollection<Lesson> Deserialize(string json)
    {
        return JsonSerializer.Deserialize<ObservableCollection<Lesson>>(json);
    }

    public string Serialize(ObservableCollection<Lesson> articles)
    {
        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
            Encoder = System.Text.Encodings.Web.JavaScriptEncoder.UnsafeRelaxedJsonEscaping
        };
        return JsonSerializer.Serialize(articles, options);
    }
}
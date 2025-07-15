# Jsoon

<p align="center">
  <img src="https://raw.githubusercontent.com/rkdcoder/jsoon/main/src/Jsoon/Media/icon.png" width="128" alt="Jsoon logo" />
</p>

[![NuGet](https://img.shields.io/nuget/v/Jsoon.svg)](https://www.nuget.org/packages/Jsoon)
[![License: MIT](https://img.shields.io/badge/License-MIT-blue.svg)](LICENSE)

---

**Jsoon** é um utilitário estático, enxuto e robusto para serialização e desserialização JSON no .NET, baseado em `System.Text.Json` com opções padronizadas e tratamento de erro customizado.

* 🚀 **Fácil de usar**: apenas `Jsoon.Serializer.Serialize(obj)` e `Jsoon.Serializer.Deserialize<T>(json)`
* 🔒 **Seguro**: todas as exceções são encapsuladas em `Jsoon.JsonSerializerException`
* 📝 **Opinionated**: utiliza camelCase, propriedades case-insensitive e ignora nulos
* ♻️ **Reusável**: pronto para qualquer aplicação .NET moderna (.NET 8+)

---

## Instalação

Via NuGet:

```shell
dotnet add package Jsoon
```

Ou, no Package Manager:

```powershell
Install-Package Jsoon
```

---

## Como usar

```csharp
using Jsoon;

var pessoa = new Pessoa { Nome = "Rodrigo", Idade = 30 };

// Serializar para JSON
string json = Jsoon.Serializer.Serialize(pessoa);

// Desserializar de JSON
var pessoa2 = Jsoon.Serializer.Deserialize<Pessoa>(json);
```

> **Obs:** Todos os erros de serialização/desserialização lançam `Jsoon.JsonSerializerException`.

### Exemplo completo

```csharp
public class Pessoa
{
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
}

var pessoa = new Pessoa { Nome = "Rodrigo", Idade = 30 };

// Serializando
string json = Jsoon.Serializer.Serialize(pessoa); // {"nome":"Rodrigo","idade":30}

// Desserializando
Pessoa? resultado = Jsoon.Serializer.Deserialize<Pessoa>(json);
```

---

## Principais opções utilizadas

* `camelCase` para nomes das propriedades
* Deserialização case-insensitive
* Ignora valores nulos ao serializar
* Baseado em `System.Text.Json` (`net8.0+`)

---

## Exceções

Todos os métodos públicos lançam **apenas** `Jsoon.JsonSerializerException` em caso de erro.

```csharp
try
{
    var obj = Jsoon.Serializer.Deserialize<MyType>("json inválido");
}
catch (JsonSerializerException ex)
{
    // Trate o erro de serialização/desserialização aqui
}
```

---

## Testes

Inclui testes unitários cobrindo cenários de sucesso e falha.

Execute localmente com:

```shell
dotnet test --configuration Release
```

---

## CI/CD

* Pipeline GitHub Actions com build, testes e publicação automática no NuGet.org.
* Veja o workflow completo em [.github/workflows/nuget.yml](.github/workflows/nuget.yml).

---

## Contribuições

Contribuições são bem-vindas!
Abra uma issue ou envie um PR com sugestões, melhorias ou correções.

---

## License

Este projeto está licenciado sob a licença MIT. Veja o arquivo [LICENSE](LICENSE) para mais detalhes.

---

**Autor:** Rodrigo
[GitHub](https://github.com/rkdcoder)

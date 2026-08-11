# BigDataCorp Desafio Batch

Um processador em lote de alta performance focado na conversão e higienização de dados de clubes de futebol. A aplicação consome um arquivo bruto no formato JSONL (JSON Lines) e o transforma em uma estrutura relacional dividida em dois arquivos CSV normalizados: `clubs.csv` e `players.csv`.

## 🛠 Pré-requisitos

Para executar este projeto, é estritamente necessário ter o **.NET 10 SDK** instalado em sua máquina.

## 🚀 Como Executar (CLI)

O sistema foi desenhado para ser invocado via interface de linha de comando. Acesse a raiz do projeto no seu terminal e utilize o comando `dotnet run`, anexando o caminho do seu arquivo `.jsonl` de entrada após os hífens (`--`).

**Exemplo de uso:**
```bash
dotnet run -- caminho/do/arquivo/sample_clubes.jsonl
```

Ao finalizar com sucesso, os arquivos de saída (`clubs.csv` e `players.csv`) serão gerados automaticamente no mesmo diretório em que o comando foi executado.

## 🧠 Destaques Técnicos

O motor principal foi arquitetado obedecendo rigorosas diretrizes de engenharia de software para processamento de Big Data:

- **Otimização Extrema de Memória (Alta Volumetria)**: O arquivo de entrada *nunca* é carregado de forma integral na memória RAM. O processo inteiro flui nativamente via `StreamReader` e `StreamWriter`, sendo lido e gravado *linha a linha*. Isso assegura que a aplicação permaneça leve e veloz mesmo ingerindo gigabytes de informações.
- **Tolerância a Falhas e Resiliência**: Arquivos volumosos frequentemente possuem sujeira estrutural. O laço de leitura encapsula o parsing em instâncias de blocos `try-catch` restritos ao nível do registro. Se um JSON for malformado, o erro é contido (logado no console) e o motor continua processando pacificamente o restante do lote.

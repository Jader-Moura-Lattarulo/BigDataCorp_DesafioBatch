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

## 🧪 Testes e Validação de Arquitetura

Para garantir a robustez e a eficiência do motor de processamento, o projeto inclui testes adicionais que validam as regras de negócio e o consumo de memória:

*   **Testes de Borda (Edge Cases):** 
    Na pasta `tests/fixtures/`, há um arquivo `testes_extremos.jsonl` contendo registros com datas inválidas, nomes com aspas e vírgulas (para forçar o escape RFC 4180), atributos nulos e times de séries não permitidas. O sistema é capaz de higienizar e filtrar esses dados sem interrupções.
    *Exemplo de uso:* `dotnet run -- tests/fixtures/testes_extremos.jsonl`

*   **Teste de Carga / Estresse (Alta Volumetria):**
    Para provar a eficácia da leitura e escrita via *Streams* (baixo consumo de memória), foi desenvolvido um script gerador de dados. O projeto `tools/DataGenerator` é capaz de criar uma base sintética com mais de 100.000 clubes e milhões de jogadores em poucos segundos, que pode ser processada pelo motor principal sem gargalos de RAM.

    ## 📂 Estruturação do Projeto e Governança

Para fins de auditoria, transparência e rastreabilidade do desenvolvimento (conforme diretrizes do desafio), o repositório está organizado com os seguintes artefatos de engenharia:

*   **Planos de Ação (`plans/`):** Todos os passos arquiteturais, divisões de tarefas e critérios de aceitação desenvolvidos antes de cada implementação de código estão arquivados nesta pasta.
*   **Histórico de IA (`conversation_history.md`):** O registro completo e transparente da interação colaborativa utilizada para projetar, refatorar e validar a solução está disponível na raiz do projeto.
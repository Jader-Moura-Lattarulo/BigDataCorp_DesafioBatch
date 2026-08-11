# Resumo da Implementação: Classe DataProcessor (Services)

## Modificações Realizadas
- O arquivo [DataProcessor.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Services/DataProcessor.cs) foi implementado com sucesso utilizando a classe `DataProcessor`.
- A arquitetura adotada usou `StreamReader` e `StreamWriter` com `using` blocks, garantindo que o processamento tenha alta performance e não carregue o JSON inteiro em memória.
- Os arquivos CSV alvo receberam gravação de cabeçalhos fixos estritos, conforme os requisitos.
- A iteração faz leitura linha a linha (lote) com as seguintes rotinas de negócio:
  - **Tolerância a Falhas**: Bloqueada por um `try-catch`, qualquer exceção de desserialização envia um aviso pelo `Console` e avança pacificamente para o próximo registro (via `continue`).
  - **Filtro de Campeonato**: Força um descarte de linhas via `continue` caso o `Championship` seja fora do eixo `"SERIE A"` ou `"SERIE B"`.
  - **Relacionamento (1:N)**: O clube é escrito no primeiro Stream. Em seguida, os elementos de `Players` (caso presentes) são transcritos para o seu próprio Stream interligando via `club.ClubId` na primeira coluna, todos sendo devidamente higienizados e escapados via `Formatter`.

## Verificação
- Compilação realizada com sucesso, ratificando a correta conversão nominal (`ClubDto` / `PlayerDto`) e das dependências dos pacotes `Models` e `Utils`.

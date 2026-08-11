# Estruturação do Processador em Lote (Services/DataProcessor.cs)

Este plano define a arquitetura e a lógica do motor principal de processamento em lote para processar o JSONL e exportar os arquivos CSV, focando em alta performance e baixo uso de memória.

## User Review Required

> [!IMPORTANT]
> Avalie se as regras de filtro de campeonato, formatação utilizando os métodos criados anteriormente e tolerância a falhas condizem com a regra de negócio. Aprove para iniciarmos a codificação.

## Proposed Changes

### 1. Criação da Classe e Método
#### [NEW] [DataProcessor.cs](file:///c:/xampp/htdocs/BigDataCorp_DesafioBatch/BigDataCorp_DesafioBatch/Services/DataProcessor.cs)
- Criar a classe `DataProcessor` no namespace `BigDataCorp_DesafioBatch.Services`.
- Definir a assinatura solicitada: `public void Process(string inputFilePath, string outputClubsPath, string outputPlayersPath)`.

### 2. Manipulação de Arquivos e Cabeçalhos
- Utilizar `using` blocks instanciando `StreamReader` para entrada e `StreamWriter` para ambas as saídas, mantendo assim o uso de memória sob controle.
- Gravar os cabeçalhos fixos antes de entrar no laço:
  - **Clubes**: `Id do Clube,Nome,Campeonato,Data de Fundação,Cidade,Estado,País,Estádio,Presidente,Apelido,Cores`
  - **Jogadores**: `Id do Clube,Id do Jogador,Nome,Idade,Gols,Data de Estreia,Posição,Número da Camisa`

### 3. Laço de Processamento
- Iniciar a leitura `while ((line = reader.ReadLine()) != null)`.
- Envolver a linha em um bloco `try-catch`. Caso a desserialização para `ClubDto` ou qualquer formatação falhe, executar `Console.WriteLine(...)` e acionar `continue`.

### 4. Regras e Formatações
- **Filtro**: Ignorar clubes se `Championship` for diferente de `"SERIE A"` e `"SERIE B"` (`continue`).
- **Formatação de Clube**: Aplicar os métodos estáticos da classe `Formatter` (`EscapeCsvField`, `FormatDate`, `FormatColors`) nos atributos e formatar a string separada por vírgulas.
- **Escrita de Clube**: Efetuar `WriteLine` em `clubsWriter`.
- **Relação 1:N (Jogadores)**: Se a coleção `Players` não for nula, realizar um iterador `foreach`. Formatar as colunas de cada jogador usando o `Formatter`, colocar o `ClubId` do clube pai na primeira coluna, e executar `WriteLine` no `playersWriter`.

## Verification Plan

### Manual Verification
- O código será desenvolvido. O utilitário `dotnet build` será usado para checar a consistência do uso de namespaces (`BigDataCorp_DesafioBatch.Models`, `BigDataCorp_DesafioBatch.Utils`) e os modelos `ClubDto` / `PlayerDto`.

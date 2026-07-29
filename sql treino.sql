
use empresa; 

#a ordem da criação das tabelas influencia
/*você pode tambem criar todas de uma vez e depois ir inseridos as restrições de chaves 
estrangeiras usando o comando alter table*/
#REVISE ISSO NO CONTEUDO DA FACULDADE!
/*CREATE TABLE Funcionarios
(
    IDfunc INT NOT NULL,
    Nome VARCHAR(30) NOT NULL,
    Salario DECIMAL(10,2) NOT NULL,
    Cargo VARCHAR(15) DEFAULT 'programador',
    #AQUI o default ta como programador caso em não insira
    #nenhum valor,mas poderia estar em branco seu eu colocasse "null" no lugar de "programador"
    Estado CHAR(2) NOT NULL,

    CONSTRAINT pk_funcionarios PRIMARY KEY (IDfunc),
    CONSTRAINT uq_nome UNIQUE (Nome)
);*/

create table Livros
(
 IDtitulo char(20) not null,
 Autor varchar(24) not null,
 Genero varchar(15) not null,
 Ano smallint not null,
 Estoque smallint not null,
 
 #chave primaria
 Constraint pk_IDT PRIMARY KEY (IDtitulo),
 #chave canditada
 constraint CC_Autor unique(Autor),
 constraint Check_v check (Ano > 2030)
 #exemplo de chave estrangeira
 #constraint FK_IDf foreign key (IDfunc) references Funcionarios (IDfunc)
);

#comando pra adicionar coluna
alter table Livros
ADD email varchar(25);

#drop column nomedacoluna,exclui a coluna
#modify modica a coluna,onde eu posso adicionar mais coisa no varchar,ou mudar uma condicão
#como por exemplo ano > 2040 se usa o modify
#sempre que criar uma tabela lembre do constraint,da chave estrangeira,
#para referencia uma chave estrangeira use o "references" logo apos 
#todos os campos NA CRIAÇÃO SÃO NOT NULL JUNTO DA CHAVE.
#ex:
#nome do campo /o tipo do campo/not null.
#usa unique para determinado campo caso ele seja um canditado a chave primaria
# parte que seria boa rever sobre unique
#

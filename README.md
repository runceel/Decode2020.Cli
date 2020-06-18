# de:code 2020 CLI�i������j

de:code 2020 �̃Z�b�V�����T�C�g����_�E�����[�h�ł���Z�b�V�������X�g�� Web API �Ƃ��Ď擾�ł��� Swagger �t�@�C���� [@TaikiYoshidaJP](https://twitter.com/TaikiYoshidaJP?s=20) ���� [de:code 2020 �Z�b�V���������p�����Power Apps](https://github.com/taiki-yoshida/decode2020-powerapps) �Ō��J���Ă��āA���� API �@���Ă����������Ă݂���������Ă����������̂ŁA�P���� CLI ���炽������悤�ɂ��Ă݂܂����B

## �C���X�g�[��

dotnet �̃O���[�o�� �c�[���Ƃ��ăC���X�g�[���ł��܂��B

NuGet �̃T�C�g�͈ȉ��ɂȂ�܂��B

[NuGet Gallery | Decode2020.Cli](https://www.nuget.org/packages/Decode2020.Cli/)

.NET Core 3.1 �� SDK ���C���X�g�[�����Ĉȉ��̃R�}���h�ŃC���X�g�[�����Ă��������B

```
$ dotnet tool install --global Decode2020.Cli --version 1.0.0
```

## �g����

### �Z�b�V�����ꗗ�̕\��

```
$ decode20 list
```

![](images/list.png)

### �L�[���[�h�Ń^�C�g�����i�荞��ŕ\��

```
$ decode20 list Azure
```

![](images/list_with_keyword.png)

### �Z�b�V���� ID �̓���{���T�C�g���J��

```
$ decode20 show A01
```

![](images/show.png)

from transformers import pipeline
from translate import Translator

a1 = pipeline("sentiment-analysis")
a2 = pipeline(model = "SamLowe/roberta-base-go_emotions")



file_with_news = open("input/News.txt", "r")

lines = file_with_news.readlines()
phrase1 = lines[0]
phrase2 = lines[1]



translator = Translator(from_lang="ru", to_lang="en")

translated_phrase1 = translator.translate(phrase1)
print(phrase1)
print(translated_phrase1.split("#")[0])

result1 = a1(translated_phrase1.split("#")[0])
result2 = a2(translated_phrase1.split("#")[0])


print(str(result1[0]['label']) + " = " + str(result1[0]['score']))
print(str(result2[0]['label']) + " = " + str(result2[0]['score']))






translated_phrase2 = translator.translate(phrase2)
print(phrase2)
print(translated_phrase2.split("#")[0])

result1 = a1(translated_phrase2.split("#")[0])
result2 = a2(translated_phrase2.split("#")[0])


print(str(result1[0]['label']) + " = " + str(result1[0]['score']))
print(str(result2[0]['label']) + " = " + str(result2[0]['score']))


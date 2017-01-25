(defproject mazes "0.1.0-SNAPSHOT"
  :description "Effort to implement the examples in the 'Mazes for Programmers' book in Clojure (next to Ruby and C#)"
  :url "https://github.com/GerbenH/mazes.git"
  :license {:name "Eclipse Public License"
            :url "http://www.eclipse.org/legal/epl-v10.html"}
  :dependencies [[org.clojure/clojure "1.8.0"]]
  :main ^:skip-aot mazes.core
  :target-path "target/%s"
  :profiles {:uberjar {:aot :all}})
